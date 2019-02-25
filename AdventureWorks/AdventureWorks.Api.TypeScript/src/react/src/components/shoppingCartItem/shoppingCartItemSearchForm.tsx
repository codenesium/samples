import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import ShoppingCartItemMapper from './shoppingCartItemMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import ShoppingCartItemViewModel from './shoppingCartItemViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface ShoppingCartItemSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ShoppingCartItemSearchComponentState {
  records: Array<ShoppingCartItemViewModel>;
  filteredRecords: Array<ShoppingCartItemViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class ShoppingCartItemSearchComponent extends React.Component<
  ShoppingCartItemSearchComponentProps,
  ShoppingCartItemSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<ShoppingCartItemViewModel>(),
    filteredRecords: new Array<ShoppingCartItemViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: ShoppingCartItemViewModel) {
    this.props.history.push(
      ClientRoutes.ShoppingCartItems + '/edit/' + row.shoppingCartItemID
    );
  }

  handleDetailClick(e: any, row: ShoppingCartItemViewModel) {
    this.props.history.push(
      ClientRoutes.ShoppingCartItems + '/' + row.shoppingCartItemID
    );
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.ShoppingCartItems + '/create');
  }

  handleDeleteClick(e: any, row: Api.ShoppingCartItemClientResponseModel) {
    axios
      .delete(
        Constants.ApiEndpoint +
          ApiRoutes.ShoppingCartItems +
          '/' +
          row.shoppingCartItemID,
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
      Constants.ApiEndpoint + ApiRoutes.ShoppingCartItems + '?limit=100';

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
            Api.ShoppingCartItemClientResponseModel
          >;
          let viewModels: Array<ShoppingCartItemViewModel> = [];
          let mapper = new ShoppingCartItemMapper();

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
            records: new Array<ShoppingCartItemViewModel>(),
            filteredRecords: new Array<ShoppingCartItemViewModel>(),
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
                Header: 'ShoppingCartItems',
                columns: [
                  {
                    Header: 'DateCreated',
                    accessor: 'dateCreated',
                    Cell: props => {
                      return <span>{String(props.original.dateCreated)}</span>;
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
                      return <span>{String(props.original.productID)}</span>;
                    },
                  },
                  {
                    Header: 'Quantity',
                    accessor: 'quantity',
                    Cell: props => {
                      return <span>{String(props.original.quantity)}</span>;
                    },
                  },
                  {
                    Header: 'ShoppingCartID',
                    accessor: 'shoppingCartID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.shoppingCartID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'ShoppingCartItemID',
                    accessor: 'shoppingCartItemID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.shoppingCartItemID)}</span>
                      );
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
                              row.original as ShoppingCartItemViewModel
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
                              row.original as ShoppingCartItemViewModel
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
                              row.original as ShoppingCartItemViewModel
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

export const WrappedShoppingCartItemSearchComponent = Form.create({
  name: 'ShoppingCartItem Search',
})(ShoppingCartItemSearchComponent);


/*<Codenesium>
    <Hash>e11d22e73d583d78a548ebb0dc857d6d</Hash>
</Codenesium>*/