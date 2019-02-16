import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import ProductPhotoMapper from './productPhotoMapper';
import Constants from '../../constants';
import ReactTable from 'react-table';
import ProductPhotoViewModel from './productPhotoViewModel';
import 'react-table/react-table.css';

interface ProductPhotoSearchComponentProps {
  history: any;
}

interface ProductPhotoSearchComponentState {
  records: Array<ProductPhotoViewModel>;
  filteredRecords: Array<ProductPhotoViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class ProductPhotoSearchComponent extends React.Component<
  ProductPhotoSearchComponentProps,
  ProductPhotoSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<Api.ProductPhotoClientResponseModel>(),
    filteredRecords: new Array<Api.ProductPhotoClientResponseModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: Api.ProductPhotoClientResponseModel) {
    this.props.history.push('/productphotoes/edit/' + row.productPhotoID);
  }

  handleDetailClick(e: any, row: Api.ProductPhotoClientResponseModel) {
    this.props.history.push('/productphotoes/' + row.productPhotoID);
  }

  handleCreateClick(e: any) {
    this.props.history.push('/productphotoes/create');
  }

  handleDeleteClick(e: any, row: Api.ProductPhotoClientResponseModel) {
    axios
      .delete(Constants.ApiUrl + 'productphotoes/' + row.productPhotoID, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
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
    let searchEndpoint = Constants.ApiUrl + 'productphotoes' + '?limit=100';

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
            Api.ProductPhotoClientResponseModel
          >;
          let viewModels: Array<ProductPhotoViewModel> = [];
          let mapper = new ProductPhotoMapper();

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
            records: new Array<ProductPhotoViewModel>(),
            filteredRecords: new Array<ProductPhotoViewModel>(),
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  filterGrid() {}

  render() {
    if (this.state.loading) {
      return <div>loading</div>;
    } else if (this.state.loaded) {
      let errorResponse: JSX.Element = <span />;

      if (this.state.deleteSubmitted) {
        if (this.state.deleteSuccess) {
          errorResponse = (
            <div className="alert alert-success">
              {this.state.deleteResponse}
            </div>
          );
        } else {
          errorResponse = (
            <div className="alert alert-danger">
              {this.state.deleteResponse}
            </div>
          );
        }
      }
      return (
        <div>
          {errorResponse}
          <form>
            <div className="form-group row">
              <div className="col-sm-4" />
              <div className="col-sm-4">
                <input
                  name="search"
                  className="form-control"
                  placeholder={'Search'}
                  value={this.state.searchValue}
                  onChange={e => this.handleSearchChanged(e)}
                />
              </div>
              <div className="col-sm-4">
                <button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center search-create-button"
                  onClick={e => this.handleCreateClick(e)}
                >
                  <i className="fas fa-plus" />
                </button>
              </div>
            </div>
          </form>
          <ReactTable
            data={this.state.filteredRecords}
            columns={[
              {
                Header: 'ProductPhoto',
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
                        <button
                          className="btn btn-sm"
                          onClick={e => {
                            this.handleDetailClick(
                              e,
                              row.original as Api.ProductPhotoClientResponseModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </button>
                        &nbsp;
                        <button
                          className="btn btn-primary btn-sm"
                          onClick={e => {
                            this.handleEditClick(
                              e,
                              row.original as Api.ProductPhotoClientResponseModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </button>
                        &nbsp;
                        <button
                          className="btn btn-danger btn-sm"
                          onClick={e => {
                            this.handleDeleteClick(
                              e,
                              row.original as Api.ProductPhotoClientResponseModel
                            );
                          }}
                        >
                          <i className="far fa-trash-alt" />
                        </button>
                      </div>
                    ),
                  },
                ],
              },
            ]}
          />
        </div>
      );
    } else if (this.state.errorOccurred) {
      return (
        <div className="alert alert-danger">{this.state.errorMessage}</div>
      );
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>5688e9c50b5907587a1a07f22c5dc046</Hash>
</Codenesium>*/