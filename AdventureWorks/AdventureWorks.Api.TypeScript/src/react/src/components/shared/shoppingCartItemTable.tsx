import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ShoppingCartItemMapper from '../shoppingCartItem/shoppingCartItemMapper';
import ShoppingCartItemViewModel from '../shoppingCartItem/shoppingCartItemViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface ShoppingCartItemTableComponentProps {
  shoppingCartItemID: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface ShoppingCartItemTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<ShoppingCartItemViewModel>;
}

export class ShoppingCartItemTableComponent extends React.Component<
  ShoppingCartItemTableComponentProps,
  ShoppingCartItemTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: ShoppingCartItemViewModel) {
    this.props.history.push(ClientRoutes.ShoppingCartItems + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: ShoppingCartItemViewModel) {
    this.props.history.push(ClientRoutes.ShoppingCartItems + '/' + row.id);
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<
            Api.ShoppingCartItemClientResponseModel
          >;

          console.log(response);

          let mapper = new ShoppingCartItemMapper();

          let shoppingCartItems: Array<ShoppingCartItemViewModel> = [];

          response.forEach(x => {
            shoppingCartItems.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: shoppingCartItems,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
    <Hash>c40a9a28776ab13ef69ba36e43885283</Hash>
</Codenesium>*/