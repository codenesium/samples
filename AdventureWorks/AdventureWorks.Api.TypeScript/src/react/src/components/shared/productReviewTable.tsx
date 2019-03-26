import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductReviewMapper from '../productReview/productReviewMapper';
import ProductReviewViewModel from '../productReview/productReviewViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface ProductReviewTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface ProductReviewTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<ProductReviewViewModel>;
}

export class ProductReviewTableComponent extends React.Component<
  ProductReviewTableComponentProps,
  ProductReviewTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

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

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.ProductReviewClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ProductReviewMapper();

        let productReviews: Array<ProductReviewViewModel> = [];

        response.data.forEach(x => {
          productReviews.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: productReviews,
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      return (
        <div>
          {message}
          <ReactTable
            data={this.state.filteredRecords}
            defaultPageSize={10}
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
                    Header: 'Email Address',
                    accessor: 'emailAddress',
                    Cell: props => {
                      return <span>{String(props.original.emailAddress)}</span>;
                    },
                  },
                  {
                    Header: 'Modified Date',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'Product I D',
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
                            props.original.productIDNavigation &&
                              props.original.productIDNavigation.toDisplay()
                          )}
                        </a>
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
                    Header: 'Review Date',
                    accessor: 'reviewDate',
                    Cell: props => {
                      return <span>{String(props.original.reviewDate)}</span>;
                    },
                  },
                  {
                    Header: 'Reviewer Name',
                    accessor: 'reviewerName',
                    Cell: props => {
                      return <span>{String(props.original.reviewerName)}</span>;
                    },
                  },
                  {
                    Header: 'Actions',
                    minWidth: 150,
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


/*<Codenesium>
    <Hash>52b998d4c70977887f0076a26b546647</Hash>
</Codenesium>*/