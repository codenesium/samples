import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ContactTypeMapper from './contactTypeMapper';
import ContactTypeViewModel from './contactTypeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { BusinessEntityContactTableComponent } from '../shared/businessEntityContactTable';

interface ContactTypeDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ContactTypeDetailComponentState {
  model?: ContactTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ContactTypeDetailComponent extends React.Component<
  ContactTypeDetailComponentProps,
  ContactTypeDetailComponentState
> {
  state = {
    model: new ContactTypeViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.ContactTypes + '/edit/' + this.state.model!.contactTypeID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.ContactTypeClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.ContactTypes +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ContactTypeMapper();

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
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>BusinessEntityContacts</h3>
            <BusinessEntityContactTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.ContactTypes +
                '/' +
                this.state.model!.contactTypeID +
                '/' +
                ApiRoutes.BusinessEntityContacts
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

export const WrappedContactTypeDetailComponent = Form.create({
  name: 'ContactType Detail',
})(ContactTypeDetailComponent);


/*<Codenesium>
    <Hash>f132105b3a5d6056e9b0d7a53093256e</Hash>
</Codenesium>*/