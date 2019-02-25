import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import BillOfMaterialMapper from './billOfMaterialMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import BillOfMaterialViewModel from './billOfMaterialViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface BillOfMaterialSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface BillOfMaterialSearchComponentState {
  records: Array<BillOfMaterialViewModel>;
  filteredRecords: Array<BillOfMaterialViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class BillOfMaterialSearchComponent extends React.Component<
  BillOfMaterialSearchComponentProps,
  BillOfMaterialSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<BillOfMaterialViewModel>(),
    filteredRecords: new Array<BillOfMaterialViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: BillOfMaterialViewModel) {
    this.props.history.push(
      ClientRoutes.BillOfMaterials + '/edit/' + row.billOfMaterialsID
    );
  }

  handleDetailClick(e: any, row: BillOfMaterialViewModel) {
    this.props.history.push(
      ClientRoutes.BillOfMaterials + '/' + row.billOfMaterialsID
    );
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.BillOfMaterials + '/create');
  }

  handleDeleteClick(e: any, row: Api.BillOfMaterialClientResponseModel) {
    axios
      .delete(
        Constants.ApiEndpoint +
          ApiRoutes.BillOfMaterials +
          '/' +
          row.billOfMaterialsID,
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
      Constants.ApiEndpoint + ApiRoutes.BillOfMaterials + '?limit=100';

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
            Api.BillOfMaterialClientResponseModel
          >;
          let viewModels: Array<BillOfMaterialViewModel> = [];
          let mapper = new BillOfMaterialMapper();

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
            records: new Array<BillOfMaterialViewModel>(),
            filteredRecords: new Array<BillOfMaterialViewModel>(),
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
                Header: 'BillOfMaterials',
                columns: [
                  {
                    Header: 'BillOfMaterialsID',
                    accessor: 'billOfMaterialsID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.billOfMaterialsID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'BOMLevel',
                    accessor: 'bOMLevel',
                    Cell: props => {
                      return <span>{String(props.original.bOMLevel)}</span>;
                    },
                  },
                  {
                    Header: 'ComponentID',
                    accessor: 'componentID',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Products +
                                '/' +
                                props.original.componentID
                            );
                          }}
                        >
                          {String(
                            props.original.componentIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'EndDate',
                    accessor: 'endDate',
                    Cell: props => {
                      return <span>{String(props.original.endDate)}</span>;
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
                    Header: 'PerAssemblyQty',
                    accessor: 'perAssemblyQty',
                    Cell: props => {
                      return (
                        <span>{String(props.original.perAssemblyQty)}</span>
                      );
                    },
                  },
                  {
                    Header: 'ProductAssemblyID',
                    accessor: 'productAssemblyID',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Products +
                                '/' +
                                props.original.productAssemblyID
                            );
                          }}
                        >
                          {String(
                            props.original.productAssemblyIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'StartDate',
                    accessor: 'startDate',
                    Cell: props => {
                      return <span>{String(props.original.startDate)}</span>;
                    },
                  },
                  {
                    Header: 'UnitMeasureCode',
                    accessor: 'unitMeasureCode',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.UnitMeasures +
                                '/' +
                                props.original.unitMeasureCode
                            );
                          }}
                        >
                          {String(
                            props.original.unitMeasureCodeNavigation.toDisplay()
                          )}
                        </a>
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
                              row.original as BillOfMaterialViewModel
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
                              row.original as BillOfMaterialViewModel
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
                              row.original as BillOfMaterialViewModel
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

export const WrappedBillOfMaterialSearchComponent = Form.create({
  name: 'BillOfMaterial Search',
})(BillOfMaterialSearchComponent);


/*<Codenesium>
    <Hash>09523001cc466b3ad5e940d40b5bf1ed</Hash>
</Codenesium>*/