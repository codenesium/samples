import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductPhotoMapper from '../productPhoto/productPhotoMapper';
import ProductPhotoViewModel from '../productPhoto/productPhotoViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface ProductPhotoTableComponentProps {
  productPhotoID: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface ProductPhotoTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<ProductPhotoViewModel>;
}

export class ProductPhotoTableComponent extends React.Component<
  ProductPhotoTableComponentProps,
  ProductPhotoTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: ProductPhotoViewModel) {
    this.props.history.push(ClientRoutes.ProductPhotoes + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: ProductPhotoViewModel) {
    this.props.history.push(ClientRoutes.ProductPhotoes + '/' + row.id);
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
            Api.ProductPhotoClientResponseModel
          >;

          console.log(response);

          let mapper = new ProductPhotoMapper();

          let productPhotoes: Array<ProductPhotoViewModel> = [];

          response.forEach(x => {
            productPhotoes.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: productPhotoes,
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
                Header: 'ProductPhotoes',
                columns: [
                  {
                    Header: 'LargePhoto',
                    accessor: 'largePhoto',
                    Cell: props => {
                      return <span>{String(props.original.largePhoto)}</span>;
                    },
                  },
                  {
                    Header: 'LargePhotoFileName',
                    accessor: 'largePhotoFileName',
                    Cell: props => {
                      return (
                        <span>{String(props.original.largePhotoFileName)}</span>
                      );
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
                    Header: 'ProductPhotoID',
                    accessor: 'productPhotoID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.productPhotoID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'ThumbNailPhoto',
                    accessor: 'thumbNailPhoto',
                    Cell: props => {
                      return (
                        <span>{String(props.original.thumbNailPhoto)}</span>
                      );
                    },
                  },
                  {
                    Header: 'ThumbnailPhotoFileName',
                    accessor: 'thumbnailPhotoFileName',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.thumbnailPhotoFileName)}
                        </span>
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
                              row.original as ProductPhotoViewModel
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
                              row.original as ProductPhotoViewModel
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
    <Hash>0d17a3f1ed8dfe624f2293938fd07e55</Hash>
</Codenesium>*/