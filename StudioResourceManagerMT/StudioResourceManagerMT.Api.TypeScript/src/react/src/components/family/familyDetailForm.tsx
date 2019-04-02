import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FamilyMapper from './familyMapper';
import FamilyViewModel from './familyViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { StudentTableComponent } from '../shared/studentTable';

interface FamilyDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface FamilyDetailComponentState {
  model?: FamilyViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class FamilyDetailComponent extends React.Component<
  FamilyDetailComponentProps,
  FamilyDetailComponentState
> {
  state = {
    model: new FamilyViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Families + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.FamilyClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Families +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new FamilyMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
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
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>Notes</h3>
              <p>{String(this.state.model!.notes)}</p>
            </div>
            <div>
              <h3>Primary Contact Email</h3>
              <p>{String(this.state.model!.primaryContactEmail)}</p>
            </div>
            <div>
              <h3>Primary Contact First Name</h3>
              <p>{String(this.state.model!.primaryContactFirstName)}</p>
            </div>
            <div>
              <h3>Primary Contact Last Name</h3>
              <p>{String(this.state.model!.primaryContactLastName)}</p>
            </div>
            <div>
              <h3>Primary Contact Phone</h3>
              <p>{String(this.state.model!.primaryContactPhone)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Students</h3>
            <StudentTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Families +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Students
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedFamilyDetailComponent = Form.create({
  name: 'Family Detail',
})(FamilyDetailComponent);


/*<Codenesium>
    <Hash>733fc48fd74478554720230c4ab21bf1</Hash>
</Codenesium>*/