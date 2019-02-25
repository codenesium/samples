import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import ProductReviewMapper from './productReviewMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import ProductReviewViewModel from './productReviewViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface ProductReviewSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductReviewSearchComponentState {
  records: Array<ProductReviewViewModel>;
  filteredRecords: Array<ProductReviewViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class ProductReviewSearchComponent extends React.Component<
  ProductReviewSearchComponentProps,
  ProductReviewSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<ProductReviewViewModel>(),
    filteredRecords: new Array<ProductReviewViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: ProductReviewViewModel) {
    this.props.history.push(
      ClientRoutes.ProductReviews + '/edit/' + row.productReviewID
    );
  }

  handleDetailClick(e: any, row: ProductReviewViewModel) {
    this.props.history.push(
      ClientRoutes.ProductReviews + '/' + row.productReviewID
    );
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.ProductReviews + '/create');
  }

  handleDeleteClick(e: any, row: Api.ProductReviewClientResponseModel) {
    axios
      .delete(
        Constants.ApiEndpoint +
          ApiRoutes.ProductReviews +
          '/' +
          row.productReviewID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          this.setState({
            ...this.state,
            deleteResponse: 'Record deleted',
            deleteSuccess: true,
            deleteSubmitted: true,
          });
          this.loadRecords(this.state.searchValue);
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            deleteResponse: 'Error deleting record',
            deleteSuccess: false,
            deleteSubmitted: true,
          });
        }
      );
  }

  handleSearchChanged(e: React.FormEvent<HTMLInputElement>) {
    this.loadRecords(e.currentTarget.value);
  }

  loadRecords(query: string = '') {
    this.setState({ ...this.state, searchValue: query });
    let searchEndpoint =
      Constants.ApiEndpoint + ApiRoutes.ProductReviews + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get(searchEndpoint, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<
            Api.ProductReviewClientResponseModel
          >;
          let viewModels: Array<ProductReviewViewModel> = [];
          let mapper = new ProductReviewMapper();

          response.forEach(x => {
            viewModels.push(mapper.mapApiResponseToViewModel(x));
          });

          this.setState({
            records: viewModels,
            filteredRecords: viewModels,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            records: new Array<ProductReviewViewModel>(),
            filteredRecords: new Array<ProductReviewViewModel>(),
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  filterGrid() {}

  render() {
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      let errorResponse: JSX.Element = <span />;

      if (this.state.deleteSubmitted) {
        if (this.state.deleteSuccess) {
          errorResponse = (
            <Alert
              message={this.state.deleteResponse}
              type="success"
              style={{ marginBottom: '25px' }}
            />
          );
        } else {
          errorResponse = (
            <Alert
              message={this.state.deleteResponse}
              type="error"
              style={{ marginBottom: '25px' }}
            />
          );
        }
      }

      return (
        <div>
          {errorResponse}
          <Row>
            <Col span={8} />
            <Col span={8}>
              <Input
                placeholder={'Search'}
                id={'search'}
                onChange={(e: any) => {
                  this.handleSearchChanged(e);
                }}
              />
            </Col>
            <Col span={8}>
              <Button
                style={{ float: 'right' }}
                type="primary"
                onClick={(e: any) => {
                  this.handleCreateClick(e);
                }}
              >
                +
              </Button>
            </Col>
          </Row>
          <br />
          <br />
          <ReactTable
            data={this.state.filteredRecords}
            columns={[
              {
                Header: 'ProductReviews',
                columns: [
                  {
                    Header: 'Comments',
                    accessor: 'comment',
                    Cell: props => {
                      return <span>{String(props.original.comment)}</span>;
                    },
                  },
                  {
                    Header: 'EmailAddress',
                    accessor: 'emailAddress',
                    Cell: props => {
                      return <span>{String(props.original.emailAddress)}</span>;
                    },
                  },
                  {
                    Header: 'ModifiedDate',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'ProductID',
                    accessor: 'productID',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Products +
                                '/' +
                                props.original.productID
                            );
                          }}
                        >
                          {String(
                            props.original.productIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'ProductReviewID',
                    accessor: 'productReviewID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.productReviewID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Rating',
                    accessor: 'rating',
                    Cell: props => {
                      return <span>{String(props.original.rating)}</span>;
                    },
                  },
                  {
                    Header: 'ReviewDate',
                    accessor: 'reviewDate',
                    Cell: props => {
                      return <span>{String(props.original.reviewDate)}</span>;
                    },
                  },
                  {
                    Header: 'ReviewerName',
                    accessor: 'reviewerName',
                    Cell: props => {
                      return <span>{String(props.original.reviewerName)}</span>;
                    },
                  },
                  {
                    Header: 'Actions',
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as ProductReviewViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as ProductReviewViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        &nbsp;
                        <Button
                          type="danger"
                          onClick={(e: any) => {
                            this.handleDeleteClick(
                              e,
                              row.original as ProductReviewViewModel
                            );
                          }}
                        >
                          <i className="far fa-trash-alt" />
                        </Button>
                      </div>
                    ),
                  },
                ],
              },
            ]}
          />
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedProductReviewSearchComponent = Form.create({
  name: 'ProductReview Search',
})(ProductReviewSearchComponent);


/*<Codenesium>
    <Hash>d92d212b8205030749416e26ef2d7b76</Hash>
</Codenesium>*/